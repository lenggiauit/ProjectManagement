import React, { useEffect, useRef, useState } from "react";
//@ts-ignore
import { Scrollbars } from 'react-custom-scrollbars';
import * as signalR from "@microsoft/signalr";
import { AppSetting } from "../../types/type";
import { Conversation } from "../../services/models/conversation";
import { useAppContext } from "../../contexts/appContext";
import { User } from "../../services/models/user";
import { Translation } from "../translation";
import { ConversationMessage } from "../../services/models/conversationMessage";
import ConversationMessageItem from "./conversationItem";
import { v4 } from "uuid";
import { useGetMessagesByConversationMutation } from "../../services/chat";
import { ResultCode } from "../../utils/enums";
import LocalSpinner from "../localSpinner";

const appSetting: AppSetting = require('../../appSetting.json');

interface Props {
    hubConnection: signalR.HubConnection,
    currentConversation?: Conversation,
    currentUser: User,
}

const ConversationDetail: React.FC<Props> = ({ hubConnection, currentConversation, currentUser }) => {

    const { locale } = useAppContext();
    const scrollbarsRef = useRef<Scrollbars>(null);
    const [listTypingUsers, setListTypingUsers] = useState<string[]>([]);
    const [listReceivedMessage, setListReceivedMessage] = useState<ConversationMessage[]>([]);

    const [getMessagesByConversation, getMessagesByConversationStatus] = useGetMessagesByConversationMutation();

    let currentTypingMessage = '';
    const handleOnTyping: React.KeyboardEventHandler<HTMLInputElement> = (e) => {

        if (e.key === 'Enter') {
            let message = e.currentTarget.value;
            if (message != '') {
                let convMessage: ConversationMessage = { conversationId: currentConversation?.id, userId: currentUser.id, message: message };
                if (hubConnection.state === 'Connected') {
                    hubConnection.send("sendMessage", JSON.stringify(convMessage));
                }
                e.currentTarget.value = currentTypingMessage = '';
            }
        }
        else {
            if (e.currentTarget.value.length > currentTypingMessage.length + 10) {
                currentTypingMessage = e.currentTarget.value;
                if (hubConnection.state === 'Connected') {
                    hubConnection.send("OnTyping", currentConversation?.id, currentUser.id);
                }
            }
            if (e.currentTarget.value.length < currentTypingMessage.length) {
                currentTypingMessage = e.currentTarget.value;
            }
        }
    }
    let isOnHandleTyping = false;
    const handleTyping = () => {
        if (isOnHandleTyping) {
            setTimeout(function () {
                setListTypingUsers([]);
                isOnHandleTyping = false;
            }, 2000);
        }
    }

    useEffect(() => {
        if (currentConversation) {
            getMessagesByConversation({ payload: { conversationId: currentConversation.id } });
        }
    }, [])

    useEffect(() => {
        if (scrollbarsRef.current != null) {
            scrollbarsRef.current.scrollToBottom();
        }
    }, [getMessagesByConversationStatus.data])

    useEffect(() => {
        if (scrollbarsRef.current != null) {
            scrollbarsRef.current.scrollToBottom();
        }
        if (hubConnection.state === 'Connected') {

            hubConnection.on("onUserTyping", (conversationId, userId) => {
                if (conversationId == currentConversation?.id && currentUser.id != userId) {
                    setListTypingUsers(prev => [...prev, userId]);
                    isOnHandleTyping = true;
                    handleTyping();
                }
            });
        }
    }, [hubConnection])

    useEffect(() => {
        if (scrollbarsRef.current != null) {
            scrollbarsRef.current.scrollToBottom();
        }
    }, [listReceivedMessage])

    useEffect(() => {
        if (scrollbarsRef.current != null) {
            scrollbarsRef.current.scrollToBottom();
        }
        if (hubConnection.state === 'Connected') {
            hubConnection.on("onReceivedMessage", receivedMessage => {
                try {
                    const convMessage = JSON.parse(receivedMessage) as ConversationMessage;
                    if (convMessage) {
                        let listMessages = listReceivedMessage;
                        listMessages.push(convMessage);
                        setListReceivedMessage([...listMessages]);
                        if (scrollbarsRef.current != null) {
                            scrollbarsRef.current.scrollToBottom();
                        }
                    }
                }
                catch {
                    console.log("error");
                }
            });
        }
    }, [hubConnection])


    if (currentConversation) {
        let title: string = currentConversation.title;
        if (title == null || title.trim().length == 0) {
            title = currentConversation.conversationers.filter(c => c.id != currentUser.id).map(c => { return c.fullName ?? c.email }).join(', ');
        }
        return (<>
            <div className="conversation-detail-container">
                <div className="message-header-container p-2">
                    <div className="row m-0" key={"message-header-container-" + v4().toString()}>
                        <div className="col-md-1 m-0 pl-0 conversation-avatars-container">
                            {currentConversation.conversationers
                                .filter(c => c.id != currentUser.id)
                                .map((c, i) =>
                                    <img key={"avatar-detail-" + i + v4().toString()} src={c.avatar ?? "/assets/images/Avatar.png"} className="rounded-circle" />
                                )}
                        </div>
                        <div className="col-md-10 text-left m-0 pr-0 pl-0 align-self-center">
                            <div>{title}</div>
                            <div>{new Date(currentConversation?.lastMessageDate).toLocaleDateString(locale)}</div>
                        </div>
                        <div className="col-md-1 text-left m-0 pr-0 pl-0 align-self-center">

                        </div>
                    </div>
                </div>
                <div className="conversation-detail-body-container p-2 ">
                    <div className="conversation-list-container overflow-auto">
                        {getMessagesByConversationStatus.isLoading && <>
                            <LocalSpinner />
                        </>}
                        {getMessagesByConversationStatus.isSuccess && <>
                            <Scrollbars ref={scrollbarsRef} >
                                {getMessagesByConversationStatus.data && getMessagesByConversationStatus.data.resource.map((item, index) =>

                                    <ConversationMessageItem key={"message-" + index + v4().toString()} message={item} currentUser={currentUser} user={currentConversation.conversationers.filter(c => c.id == item.userId)[0]} />

                                )}
                                {listReceivedMessage.map((item, index) =>

                                    <ConversationMessageItem key={"message-" + index + v4().toString()} message={item} currentUser={currentUser} user={currentConversation.conversationers.filter(c => c.id == item.userId)[0]} />

                                )}
                            </Scrollbars>
                        </>}
                    </div>
                    <div className="conversation-detail-typing-users">
                        {listTypingUsers.length > 0 && <> <div>
                            <div className="d-inline">
                                {currentConversation.conversationers
                                    .filter(c => listTypingUsers.find(l => l = c.id))
                                    .filter(c => c.id != currentUser.id)
                                    .map((c, i) =>

                                        <img key={"avatar-detail-" + i + v4().toString()} src={c.avatar ?? "/assets/images/Avatar.png"} className="rounded-circle typing-avatar" />

                                    )}
                            </div>
                            <div className="d-inline"><Translation tid="isTyping" /></div>
                        </div>
                        </>}
                    </div>
                </div>

                <div className="message-bottom-container p-2">
                    <div className="d-inline">
                        <input type="text" onKeyDown={handleOnTyping} className="form-control form-control-md rounded-pill" placeholder="Aa" />
                    </div>
                </div>
            </div>
        </>);
    }
    else {
        return (<> </>)
    }
}

export default ConversationDetail;