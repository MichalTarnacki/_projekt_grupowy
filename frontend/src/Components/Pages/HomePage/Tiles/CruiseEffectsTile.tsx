import Tile from "./Tile";
import {Link} from "react-router-dom";
import {Path as Path} from "../../../Tools/Path";
import React from "react";
import {ReactComponent as Icon} from "/node_modules/bootstrap-icons/icons/award-fill.svg"

function MyPublicationsTile(){
    return (
        <Tile>
            <Link to={Path.CruiseEffects} className={"common-tile-link"}>
                <Icon className={"bi-menu-common"}/>
                Efekty rejsów
            </Link>
        </Tile>
    )
}

export default MyPublicationsTile;