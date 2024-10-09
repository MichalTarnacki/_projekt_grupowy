import Tile from "./Tile";
import {Link} from "react-router-dom";
import {Path as Path} from "../../../Tools/Path";
import React from "react";
import {ReactComponent as Icon} from "/node_modules/bootstrap-icons/icons/book.svg"

function MyPublicationsTile(){
    return (
        <Tile>
            <Link to={Path.MyPublications} className={"common-tile-link"}>
                <Icon className={"bi-menu-common"}/>
                Moje Publikacje
            </Link>
        </Tile>
    )
}

export default MyPublicationsTile;
