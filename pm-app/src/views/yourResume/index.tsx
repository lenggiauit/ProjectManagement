import React, { ReactElement } from 'react';
import { useSelector } from 'react-redux';
import { Redirect } from 'react-router-dom';
import Layout from '../../components/layout';
import { selectUser } from "../../store/userSlice";
import { decrypt } from '../../utils/crypter';
import { getLoggedUser } from '../../utils/functions';
import * as bt from 'react-bootstrap';


const YourResume: React.FC = (): ReactElement => {

    return (
        <>
            <Layout>
                <bt.Container>
                    <bt.Row>
                        <h1>Your CV</h1>
                    </bt.Row>
                </bt.Container>
            </Layout>

        </>
    );
}

export default YourResume;