import React, { ReactElement } from 'react';
import { useSelector } from 'react-redux';
import { Redirect } from 'react-router-dom';
import { selectUser } from "../../store/userSlice";
import { decrypt } from '../../utils/crypter';
import { getLoggedUser } from '../../utils/functions';

const Home: React.FC = (): ReactElement => {

    const currentUser = getLoggedUser();

    if (currentUser != null) {
        return (
            <>
                <h1>Home</h1>
                <h2>{currentUser.accessToken}</h2>
            </>
        );
    }
    else {
        return (
            <Redirect to='/login' />
        );
    }

}

export default Home;