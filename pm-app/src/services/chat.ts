import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiRequest, ApiResponse, AppSetting } from "../types/type";
import { getLoggedUser } from '../utils/functions';
import { Conversation } from './models/conversation';
import { GetConversationListRequest, GetMessagesRequest } from './communication/request/getConversationListRequest';
import * as signalR from "@microsoft/signalr";
import { ConversationMessage } from './models/conversationMessage';
let appSetting: AppSetting = require('../appSetting.json');

export const signalRHubConnection = new signalR.HubConnectionBuilder()
    .withUrl(appSetting.BaseUrl + "conversationServiceHub", {
        accessTokenFactory: () => getLoggedUser()?.accessToken,
    })
    .withAutomaticReconnect()
    .build();

export const StartSignalRHubConnection = () => {
    if (!CheckSignalRHubConnection()) {
        signalRHubConnection.start().then(() => {
            // check connection
            signalRHubConnection.send("checkConnectionStatus", getLoggedUser()?.id);
            // receive connection status
            signalRHubConnection.on("onCheckConnectionStatus", message => {
                console.log(message);
            });
        }).catch((ex) => {
            console.log(ex);
        });
    }
}

export const CheckSignalRHubConnection = () => {
    return signalRHubConnection.state === 'Connected';
}

export const StopSignalRHubConnection = () => {
    signalRHubConnection.stop();
}

export const ChatService = createApi({
    reducerPath: 'ChatService',

    baseQuery: fetchBaseQuery({
        baseUrl: appSetting.BaseUrl,
        prepareHeaders: (headers) => {
            const currentUser = getLoggedUser();
            // Add token to headers
            if (currentUser && currentUser.accessToken) {
                headers.set('Authorization', `Bearer ${currentUser.accessToken}`);
            }
            return headers;
        },
    }),
    endpoints: (builder) => ({
        GetConversationListByUser: builder.mutation<ApiResponse<Conversation[]>, ApiRequest<GetConversationListRequest>>({
            query: (payload) => ({
                url: 'chat/getConversationListByUser',
                method: 'post',
                body: payload,

            }),
            transformResponse(response: ApiResponse<Conversation[]>) {
                return response;
            },
        }),
        GetMessagesByConversation: builder.mutation<ApiResponse<ConversationMessage[]>, ApiRequest<GetMessagesRequest>>({
            query: (payload) => ({
                url: 'chat/getMessagesByConversation',
                method: 'post',
                body: payload,

            }),
            transformResponse(response: ApiResponse<ConversationMessage[]>) {
                return response;
            },
        }),
    })
});

export const { useGetConversationListByUserMutation, useGetMessagesByConversationMutation } = ChatService;