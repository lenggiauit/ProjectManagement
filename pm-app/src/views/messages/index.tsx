import React, { ReactElement, useEffect, useState } from 'react';
import Layout from '../../components/layout';
import { getLoggedUser } from '../../utils/functions';
import { Translation } from '../../components/translation';
import Conversationer from '../../components/messages/conversationer';
//@ts-ignore
import { Scrollbars } from 'react-custom-scrollbars';
import ConversationDetail from '../../components/messages/conversationDetail';
import { signalRHubConnection, StartSignalRHubConnection, StopSignalRHubConnection, useGetConversationListByUserMutation } from '../../services/chat';
import { ResultCode } from '../../utils/enums';
import { Conversation } from '../../services/models/conversation';
import { v4 } from 'uuid';
import LocalSpinner from '../../components/localSpinner';
import * as signalR from "@microsoft/signalr";
import { AppSetting } from '../../types/type';
import { toast } from 'react-toastify';
import { dictionaryList } from '../../locales';
import { useAppContext } from '../../contexts/appContext';
const appSetting: AppSetting = require('../../appSetting.json');

const Message: React.FC = (): ReactElement => {

    const { locale, } = useAppContext();
    const currentUser = getLoggedUser()!;
    const [GetConversationListByUser, GetConversationListByUserStatus] = useGetConversationListByUserMutation();
    const [selectedConversation, setSelectedConversation] = useState<Conversation>();
    const [isSelectedConversation, setIsSelectedConversation] = useState<boolean>(false);
    const [currentListConversations, setCurrentListConversations] = useState<Conversation[]>([]);
    const selectedConversationHandler = (conv: Conversation) => {
        if (signalRHubConnection.state === 'Connected') {
            signalRHubConnection.send("startConversation", conv.id, JSON.stringify(conv));

        }
    };
    // setCurrentListConversations when GetConversationListByUser compeleted 
    useEffect(() => {
        if (GetConversationListByUserStatus.isSuccess && GetConversationListByUserStatus.data && GetConversationListByUserStatus.data.resultCode == ResultCode.Success) {
            setCurrentListConversations(prev => ([...prev, ...GetConversationListByUserStatus.data.resource]));
        }
    }, [GetConversationListByUserStatus])
    // Start onload
    useEffect(() => {
        GetConversationListByUser({ payload: { userId: currentUser?.id } });
        StartSignalRHubConnection();
        return () => {
            StopSignalRHubConnection();
        }
    }, []);

    useEffect(() => {
        signalRHubConnection.on("onStartConversation", conversationInfo => {
            try {
                const convInfo = JSON.parse(conversationInfo) as Conversation;
                if (!isSelectedConversation) {
                    if (currentListConversations.find(c => c.id === convInfo.id)) {
                        setSelectedConversation(convInfo);
                        setIsSelectedConversation(true);
                        console.log("have conversation");
                    }
                    else {
                        console.log("no conversation");
                    }
                }
                else {

                }
            }
            catch {
                toast.error(dictionaryList[locale]["Error"]);
            }
        });
    }, [currentListConversations])


    return (
        <>
            <Layout>
                <div className="container height-100vh-60px">
                    <div className="row h-100">
                        <div className="col-sm-3 border-right p-0 pt-2">
                            <h2><Translation tid="Chats" /></h2>
                            <div className="form-group m-2 mb-5">
                                <div className="d-inline">
                                    <input type="text" className="form-control form-control-sm rounded-pill" placeholder="Search messenger" />
                                </div>
                            </div>
                            {(GetConversationListByUserStatus.isLoading) &&
                                <>
                                    <LocalSpinner />
                                </>
                            }
                            <div className="conversationer-container overflow-auto">
                                <Scrollbars key={"message-scrollbars-" + v4().toString()} >
                                    {!GetConversationListByUserStatus.error
                                        && GetConversationListByUserStatus.data?.resultCode == ResultCode.Success && GetConversationListByUserStatus.data?.resource != null &&
                                        <> {
                                            GetConversationListByUserStatus.data?.resource.map((item, index) => (
                                                <>
                                                    <Conversationer key={"conversationer-" + index + v4().toString() + item.id} data={item} selectedConversation={selectedConversationHandler} currentUser={currentUser} />
                                                </>
                                            ))
                                        }
                                        </>
                                    }
                                </Scrollbars>
                            </div>
                        </div>
                        <div className="col-sm-9">
                            <ConversationDetail key={v4()} hubConnection={signalRHubConnection} currentConversation={selectedConversation} currentUser={currentUser} />
                        </div>
                    </div>
                </div>
            </Layout>

        </>
    );
}

export default Message;