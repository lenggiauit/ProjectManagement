import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import Navigation from '../../components/navigation/'
import { AppProvider } from '../../contexts/appContext';


const Layout: React.FC = ({ children }): ReactElement => {
    return (
        <>
            <AppProvider>
                <bt.Container className="justify-content-md-center">
                    <bt.Row>
                        <Navigation />
                    </bt.Row>
                </bt.Container>
                {children}
            </AppProvider>
        </>
    )
};

export default Layout;