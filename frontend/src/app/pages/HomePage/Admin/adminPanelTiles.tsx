import NewCruiseApplicationTile from '../../../../components/MainPageMenu/Tiles/NewCruiseApplicationTile';
import SavedCruiseApplicationsTile from '../../../../components/MainPageMenu/Tiles/SavedCruiseApplicationsTile';
import ManageUserTile from '../../../../components/MainPageMenu/Tiles/ManageUserTile';
import AccountSettingsTile from '../../../../components/MainPageMenu/Tiles/AccountSettingsTile';
import CruiseApplicationsTile from '../../../../components/MainPageMenu/Tiles/CruiseApplicationsTile';
import CruisesTile from '../../../../components/MainPageMenu/Tiles/CruisesTile';
import React from 'react';

export const adminPanelTiles = () => [
  { element: <NewCruiseApplicationTile />, cols: 2, rows: 2 },
  { element: <SavedCruiseApplicationsTile />, cols: 2, rows: 1 },
  { element: <ManageUserTile />, cols: 1, rows: 1 },
  { element: <AccountSettingsTile />, cols: 1, rows: 2 },
  { element: <CruiseApplicationsTile />, cols: 1, rows: 1 },
  { element: <CruisesTile />, cols: 2, rows: 1 },
];
