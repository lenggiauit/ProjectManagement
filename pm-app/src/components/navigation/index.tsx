import React, { useState } from 'react'
import { useLocation } from 'react-router-dom';
import * as bt from 'react-bootstrap';
import { Translation } from '../../components/translation/'
import { LanguageSelector } from '../languageSelector';
import { AppProvider } from '../../contexts/appContext';
import { logout } from '../../utils/functions';
import { AnimationLogo } from '../animationLogo';
const Navigation: React.FC = () => {
    return (
        <>

            <nav className="navbar navbar-expand-lg navbar-dark">
                <div className="container">

                    <div className="navbar-left mr-4">
                        <button className="navbar-toggler" type="button"><span className="navbar-toggler-icon"></span></button>
                        <a className="navbar-brand" href="/">
                            <AnimationLogo width={45} height={45} />
                        </a>
                    </div>
                    <section className="navbar-mobile">
                        <span className="navbar-divider d-mobile-none"></span>
                        <nav className="nav nav-navbar nav-text-normal mr-auto">
                            <a className="nav-link" href="/"><Translation tid="nav_dashboard" /></a>
                            <a className="nav-link" href="/projects"><Translation tid="nav_projects" /></a>
                            <a className="nav-link" href="/teams"><Translation tid="nav_teams" /></a>
                            <a className="nav-link" href="/messages"><Translation tid="nav_messages" /></a>
                            <a className="nav-link" href="/profile"><Translation tid="nav_profile" /></a>
                            <a className="nav-link" href="#" onClick={() => logout()}><Translation tid="nav_logout" /></a>
                        </nav>
                        <LanguageSelector />
                    </section>

                </div>
            </nav>
        </>
    )
};

export default Navigation;