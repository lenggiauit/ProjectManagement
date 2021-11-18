import React, { useContext, MouseEvent } from 'react';
import { localeOptions } from '../../locales';
import { useAppContext } from '../../contexts/appContext';
import * as bt from 'react-bootstrap';

export const LanguageSelector: React.FC = () => {
    const { locale, setLocale } = useAppContext();
    const handleLanguageChange: React.MouseEventHandler<HTMLAnchorElement> = (e) => {
        var selectLang = (e.target as HTMLAnchorElement).id;
        window.localStorage.setItem('covid-19-tracking-lang', selectLang);
        setLocale(selectLang);
        console.log(selectLang);
    }
    return (
        <>
            <bt.NavDropdown title={localeOptions[locale]} id="languageSelector">
                {Object.entries(localeOptions).map(([id, name]) => (
                    <bt.NavDropdown.Item key={id} id={id} onClick={handleLanguageChange}>{name}</bt.NavDropdown.Item>
                ))}
            </bt.NavDropdown>
        </>
    );
};