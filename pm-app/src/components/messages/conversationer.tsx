import React from "react";
import { v4 } from "uuid";
import { Conversation } from "../../services/models/conversation";
import { User } from "../../services/models/user";

type Props = {
    data?: Conversation,
    selectedConversation(arg?: Conversation): void,
    currentUser: User,
}

const Conversationer: React.FC<Props> = ({ data, selectedConversation, currentUser }) => {

    if (data) {
        let title: string = data.title;
        if (title.trim().length == 0) {
            title = data.conversationers.filter(c => c.id != currentUser.id).map(c => { return c.fullName ?? c.email }).join(', ');
        }
        return (<>
            <div className="conversationer-item-container" onClick={() => { selectedConversation(data) }}>
                <div className="conversationer-item-body-container p-2">
                    <div className="row m-0">
                        <div className="col-md-4 m-0 pl-0 conversation-avatars-container">
                            {data.conversationers
                                .filter(c => c.id != currentUser.id)
                                .map((c, i) =>
                                    <>
                                        <img key={"avatar-" + i + v4().toString()} src={c.avatar ?? "/assets/images/Avatar.png"} className="rounded-circle" />
                                    </>
                                )}
                        </div>
                        <div className="col-md-8 text-left m-0 pr-0 pl-0 align-self-center">
                            <div>{title}</div>
                            <div>{data.lastMessage}</div>
                        </div>
                    </div>
                </div>
            </div>
        </>);
    }
    else {
        return (<> </>);
    }
}

export default Conversationer;