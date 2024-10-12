import Home from '../../../../app/pages/HomePage/Home';
import TilesMenu from './TilesMenu';
import React from 'react';
import { TileType } from 'TileType';

export const TilesMenuWrapper = (props: { tiles: () => TileType[] }) => (
    <Home>
        <TilesMenu tiles={props.tiles()} />
    </Home>
);
