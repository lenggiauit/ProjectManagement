import React, { ReactElement, useEffect, useState } from 'react';
import Layout from '../../components/layout';
import { getLoggedUser } from '../../utils/functions';
import { Translation } from '../../components/translation';
import Conversationer from '../../components/messages/conversationer';
//@ts-ignore
import { Scrollbars } from 'react-custom-scrollbars';
import ConversationDetail from '../../components/messages/conversationDetail';
import { signalRHubConnection, StartSignalRHubConnection, StopSignalRHubConnection, useConversationalSearchKeywordMutation, useGetConversationListByUserMutation } from '../../services/chat';
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
    const [conversationalSearchKeyword, ConversationalSearchKeywordStatus] = useConversationalSearchKeywordMutation();
    const [selectedConversation, setSelectedConversation] = useState<Conversation>();

    const [currentConversationTying, setcurrentConversationTying] = useState<Conversation>();

    const [isSelectedConversation, setIsSelectedConversation] = useState<boolean>(false);
    const [isSearchingUser, setIsSearchingUser] = useState<boolean>(false);
    const [currentListConversations, setCurrentListConversations] = useState<Conversation[]>([]);
    const selectedConversationHandler = (conv: Conversation) => {
        // console.log(conv.id);
        // if (signalRHubConnection.state === 'Connected') {
        //     //signalRHubConnection.send("startConversation", conv.id, JSON.stringify(conv));

        // }
        setSelectedConversation(conv);
    };
    // setCurrentListConversations when GetConversationListByUser compeleted 
    useEffect(() => {
        if (GetConversationListByUserStatus.isSuccess && GetConversationListByUserStatus.data && GetConversationListByUserStatus.data.resultCode == ResultCode.Success) {
            setCurrentListConversations(prev => ([...prev, ...GetConversationListByUserStatus.data.resource]));
        }
    }, [GetConversationListByUserStatus])
    // Start onload
    useEffect(() => {
        StartSignalRHubConnection();
        GetConversationListByUser({ payload: { userId: currentUser?.id } });

        return () => {
            StopSignalRHubConnection();
        }
    }, []);


    // setTimeout(() => {
    //     if (signalRHubConnection.state === 'Connected') {
    //         currentListConversations.map((conv) => {
    //             signalRHubConnection.send("startConversation", conv.id, JSON.stringify(conv));
    //             console.log("Send startConversation 111: " + conv.id);
    //         }
    //         )
    //     }

    // }, 1000);

    useEffect(() => {

        if (signalRHubConnection.state === 'Connected') {
            currentListConversations.map((conv) => {
                setTimeout(() => {
                    signalRHubConnection.send("startConversation", conv.id, JSON.stringify(conv));
                    // console.log("Send startConversation: " + conv.id);
                }, 2000);
            });
        }

    }, [currentListConversations])



    // useEffect(() => {
    //     if (signalRHubConnection.state == 'Connected') {
    //         signalRHubConnection.on("onStartConversation", conversationInfo => {
    //             try {
    //                 const convInfo = JSON.parse(conversationInfo) as Conversation;

    //                 if (!isSelectedConversation) {
    //                     if (currentListConversations.find(c => c.id === convInfo.id)) {
    //                         // setSelectedConversation(convInfo);
    //                         // setIsSelectedConversation(true);
    //                         //console.log("have conversation");
    //                     }
    //                     else {
    //                         //console.log("no conversation");
    //                     }
    //                 }
    //                 else {

    //                 }
    //             }
    //             catch {
    //                 toast.error(dictionaryList[locale]["Error"]);
    //             }

    //         });
    //     }
    // }, [currentListConversations])

    // handle user focus on chat message
    let windowIsOnFocus = true;
    const onWindowFocus = () => {
        StartSignalRHubConnection();
        windowIsOnFocus = true;
    };

    const onWindowBlur = () => {

        setTimeout(() => {
            if (!windowIsOnFocus) {
                StopSignalRHubConnection();
                windowIsOnFocus = false;
            }
        }, 15000);

    };
    // 
    const WindowFocusHandler = () => {
        useEffect(() => {
            window.addEventListener('focus', onWindowFocus);
            window.addEventListener('blur', onWindowBlur);
            return () => {
                window.removeEventListener('focus', onWindowFocus);
                window.removeEventListener('blur', onWindowBlur);
            };
        });
    };
    WindowFocusHandler();

    // handle searching user 
    const handleSeachingUser: React.KeyboardEventHandler<HTMLInputElement> = (e) => {
        let searchkeys = e.currentTarget.value;
        if (searchkeys.length >= 3 && e.key !== 'Backspace') {
            setIsSearchingUser(true);
            conversationalSearchKeyword({ payload: { keyword: searchkeys } });
        }
        if (searchkeys.length == 0) {
            setIsSearchingUser(false);
        }
    }
    // render
    return (
        <>
            <Layout>
                <div className="container height-100vh-60px">
                    <div className="row h-100">
                        <div className="col-sm-3 border-right p-0 pt-2">
                            <h2><Translation tid="Chats" /></h2>
                            <div className="form-group m-2 mb-5">
                                <div className="d-inline">
                                    <input type="text" className="form-control form-control-sm rounded-pill" onKeyDown={handleSeachingUser} placeholder="Search messenger" />
                                </div>
                            </div>
                            {((GetConversationListByUserStatus.isLoading) || (ConversationalSearchKeywordStatus.isLoading)) &&
                                <>
                                    <LocalSpinner />
                                </>
                            }
                            <div className="conversationer-container overflow-auto">
                                {!isSearchingUser && <>
                                    <Scrollbars key={"message-scrollbars-" + v4().toString()} >
                                        {!GetConversationListByUserStatus.error
                                            && GetConversationListByUserStatus.data?.resultCode == ResultCode.Success && GetConversationListByUserStatus.data?.resource != null &&
                                            <> {
                                                GetConversationListByUserStatus.data?.resource.map((item, index) => (
                                                    <Conversationer key={"conversationer-" + index + v4().toString() + item.id} hubConnection={signalRHubConnection} data={item} selectedConversationEvent={selectedConversationHandler} currentUser={currentUser} selectedConversation={selectedConversation} />

                                                ))
                                            }
                                            </>
                                        }
                                    </Scrollbars>
                                </>}
                                {isSearchingUser && <>
                                    <Scrollbars key={"message-search-scrollbars-" + v4().toString()} >
                                        {!ConversationalSearchKeywordStatus.error
                                            && ConversationalSearchKeywordStatus.data?.resultCode == ResultCode.Success && ConversationalSearchKeywordStatus.data?.resource != null &&
                                            <> {
                                                ConversationalSearchKeywordStatus.data?.resource.map((item, index) => (

                                                    <Conversationer key={"conversationer-" + index + v4().toString() + item.id} data={item} hubConnection={signalRHubConnection} selectedConversationEvent={selectedConversationHandler} currentUser={currentUser} selectedConversation={selectedConversation} />

                                                ))
                                            }
                                            </>
                                        }
                                    </Scrollbars>
                                </>}
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