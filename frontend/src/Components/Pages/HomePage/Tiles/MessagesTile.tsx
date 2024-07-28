import React  from 'react';
import CSSModules from 'react-css-modules';
import Style from './style.css'
import Tile from "./Tile";
import {Link} from "react-router-dom";


function MessagesTile( ){
    return (
        <Tile>
            <Link to="/Messages"  className={"p-3 d-flex flex-column w-100 h-100 align-items-center text-decoration-none"}>
                <svg xmlns="http://www.w3.org/2000/svg" className={"h-100 w-100"} fill="black"
                     className="bi bi-chat-fill" viewBox="0 0 16 16">
                    <path
                        d="M8 15c4.418 0 8-3.134 8-7s-3.582-7-8-7-8 3.134-8 7c0 1.76.743 3.37 1.97 4.6-.097 1.016-.417 2.13-.771 2.966-.079.186.074.394.273.362 2.256-.37 3.597-.938 4.18-1.234A9 9 0 0 0 8 15"/>
                </svg>
                 Wiadomości
            </Link>
        </Tile>
    )
}


export default MessagesTile