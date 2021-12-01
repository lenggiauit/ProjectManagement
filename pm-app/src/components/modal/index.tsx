import React from "react";
import { render, unmountComponentAtNode } from 'react-dom'
import { Translation } from "../translation";

type Props = {
    options: PropTypes
}

const ConfirmModal: React.FC<Props> = ({ options }) => {

    const pmModalDialogId = "pm-modal-dialog";

    const removeModalComponent = (): void => {
        const target = document.getElementById(pmModalDialogId);
        if (target) {
            unmountComponentAtNode(target);
        }

    }
    const onCloseHandler: React.MouseEventHandler<HTMLButtonElement> = () => {
        removeModalComponent();
    }
    const onCancelHandler: React.MouseEventHandler<HTMLButtonElement> = () => {
        removeModalComponent();
        if (options.onCancel)
            options.onCancel();
    }
    const onConfirmHandler: React.MouseEventHandler<HTMLButtonElement> = () => {
        removeModalComponent();
        options.onConfirm();
    }

    return (<>
        <div className="modal fade show" id="modal-default" role="dialog" aria-labelledby="exampleModalLabel" aria-modal="true">
            <div className="modal-dialog" role="document">
                <div className="modal-content">
                    {options.title && <>
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">{options.title}</h5>
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close" onClick={onCloseHandler} >
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                    </>}
                    <div className="modal-body pb-0">
                        <p className="m-0">{options.message}</p>
                    </div>
                    <div className="modal-footer border-0">
                        <button type="button" className="btn btn-secondary" onClick={onCancelHandler} data-dismiss="modal"><Translation tid="btnClose" /></button>
                        <button type="button" className="btn btn-primary" onClick={onConfirmHandler} ><Translation tid="btnConfirm" /></button>
                    </div>
                </div>
            </div>
        </div>

    </>);
}

type PropTypes = {
    title?: any,
    message: any,
    onConfirm: () => void,
    onCancel?: () => void,
}

const showConfirmModal = (options: PropTypes) => {
    let divTarget = document.getElementById('pm-modal-dialog');
    if (divTarget) {
        render(<ConfirmModal options={options} />, divTarget);
    } else {

        divTarget = document.createElement('div');
        divTarget.id = 'pm-modal-dialog';
        document.body.appendChild(divTarget);
        render(<ConfirmModal options={options} />, divTarget);
    }

}

export default showConfirmModal;