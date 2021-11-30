import React from "react";
import { ConversationMessage } from "../../services/models/conversationMessage";
import { User } from "../../services/models/user";

type Props = {
    message: ConversationMessage,
    user: User,
    currentUser: User,
}

const ConversationMessageItem: React.FC<Props> = ({ message, user, currentUser }) => {
    if (message && user) {
        return (<>

            <div className="row m-0 conversation-item-container">
                {user.id != currentUser.id && <>
                    <div className="col-md-1 ">
                        <img src={user.avatar ?? "/assets/images/Avatar.png"} className="rounded-circle" />
                    </div>
                    <div className="col-md-11 text-left m-0 pr-0 pl-0 align-self-center">
                        <p className="p-2 pl-0">{message.message}</p>
                    </div>
                </>}
                {user.id == currentUser.id && <>
                    <div className="col-md-12 text-right m-0 pr-0 pl-0 align-self-center">
                        <p className="bg-primary bg-rounded rounded text-white d-inline p-2">{message.message}</p>
                    </div>
                </>}

            </div>

        </>);
    }
    else {
        return (<> </>);
    }

}

export default ConversationMessageItem;