import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import { Redirect } from 'react-router-dom';
import Navigation from '../../components/navigation/'
import { AppProvider } from '../../contexts/appContext';
import { getLoggedUser } from '../../utils/functions';


const Layout: React.FC = ({ children }): ReactElement => {

    const currentUser = getLoggedUser();

    if (currentUser != null) {
        return (
            <>
                <AppProvider>
                    <bt.Container className="nav-container">
                        <bt.Row>
                            <Navigation />
                        </bt.Row>
                    </bt.Container>
                    {children}
                </AppProvider>
            </>
        )
    }
    else {
        return (
            <Redirect to='/login' />
        );
    }
};

export default Layout;