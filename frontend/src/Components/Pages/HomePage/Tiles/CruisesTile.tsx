import React  from 'react';
import Tile from "./Tile";
import {Link} from "react-router-dom";
import {PathName as Path} from "../../../Tools/PathName";
import {ReactComponent as Icon} from "/node_modules/bootstrap-icons/icons/calendar-check-fill.svg"

function CruisesTile(){
    return (
        <Tile>
            <Link to={Path.Cruises} className={"common-tile-link"}>
                <Icon className={"bi-menu-common"}/>
                Harmonogram rejsów
            </Link>
        </Tile>
    )
}


export default CruisesTile