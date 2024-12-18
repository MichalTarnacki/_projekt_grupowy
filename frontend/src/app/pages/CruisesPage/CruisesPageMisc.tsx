import React, { useContext, useState } from 'react';
import ButtonWithState from '../../../components/Navigation/ButtonWithState';
import { CruiseStateContext } from './CruisesPage';
import CruisesList from './CruisesList';
import ReactSwitch from 'react-switch';
import CruisesCalendar from './CruisesCalendar';
import UserBasedAccess from '../../../route/UserBasedAccess';
import { Path } from '../../../ToBeMoved/Tools/Path';
import { fetchCruises } from '@api/requests';
import { autoAddCruises } from '@api/requests/Put';
import { deleteCruise } from '@api/requests/Delete';
import { sortCruiseApplicationsByNumber } from '@app/pages/CruiseApplicationsPage/CruiseApplicationsList/CruiseApplicationsListMisc';
import { Cruise } from 'Cruise';
import { sortCruiseListByNumber } from '@app/pages/CruisesPage/CruiseListFilterAndSort';

export const ModeSwitch = () => {
  const [listView, setListView] = useState(true);
  return {
    CalendarListSwitch: () => (
      <div className='d-flex   align-items-center p-3 w-50'>
        <div className='pe-2'>Kalendarz</div>
        <ReactSwitch
          className={'custom-switch'}
          checked={listView}
          checkedIcon={false}
          uncheckedIcon={false}
          onChange={() => {
            setListView(!listView);
          }}
        />
        <div className='ps-2'>Lista</div>
      </div>
    ),
    listView: listView,
  };
};

export const LoadCruises = () => {
  const cruiseStateContext = useContext(CruiseStateContext);
  return () =>
    fetchCruises().then((response) =>
      cruiseStateContext!.setCruises(
        response ? sortCruiseListByNumber(response?.data).reverse() : []
      )
    );
};
export const AddCruiseButtons = () => {
  const loadCruises = LoadCruises();
  return (
    <div className='d-flex flex-row  flex-wrap justify-content-end align-items-center w-50 '>
      <button
        className='cruises-button'
        onClick={() => autoAddCruises().then(() => loadCruises())}
      >
        Dodaj rejsy automatycznie
      </button>
      <ButtonWithState
        className='cruises-button'
        to={Path.CruiseForm}
        label='Nowy rejs'
      />
    </div>
  );
};

export const CruisePageContent = () => {
  const { CalendarListSwitch, listView } = ModeSwitch();
  const { UserHasShipownerAccess, UserHasAdminAccess } = UserBasedAccess();
  const OptionBar = () => (
    <div className={'d-none d-md-flex flex-row w-100'}>
      <CalendarListSwitch />
      {(UserHasAdminAccess() || UserHasShipownerAccess()) && (
        <AddCruiseButtons />
      )}
    </div>
  );

  return (
    <>
      <OptionBar />
      {!listView && <CruisesCalendar />}
      {listView && <CruisesList />}
    </>
  );
};

export const HandleDeleteCruises = () => {
  const cruiseStateContext = useContext(CruiseStateContext);
  return (id: string) =>
    deleteCruise(id).then((_) => {
      const newCruises = cruiseStateContext!.cruises.filter(
        (cruise) => cruise.id != id
      );
      cruiseStateContext!.setCruises!(newCruises);
    });
};
