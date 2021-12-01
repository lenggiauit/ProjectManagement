import { type } from "os";
import { User } from "../../models/user";

export type GetConversationListRequest = {
    userId: any,
};

export type GetMessagesRequest = {
    conversationId: any,
};
export type ConversationalSearchRequest = {
    keyword: any
}

export type CreateConversationRequest = {
    id: any,
    users: string[],

}