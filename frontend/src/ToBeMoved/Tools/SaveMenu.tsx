import {
  fileName,
  handleDownload,
  handlePrint,
  handleSave,
} from './FormButtonsHandlers';
import React, { useContext, useState } from 'react';
import { ReactComponent as DownloadIcon } from '/node_modules/bootstrap-icons/icons/download.svg';
import { ReactComponent as CancelIcon } from '/node_modules/bootstrap-icons/icons/x-lg.svg';
import { FormContext } from '@contexts/FormContext';
import { FormContextFields } from '@app/pages/FormPage/Wrappers/FormTemplate';
import { refillFormB, refillFormC } from '@api/requests/Put';
import { useNavigate } from 'react-router-dom';
import { extendedUseLocation } from '@hooks/extendedUseLocation';
import { CruiseApplicationStatus } from 'CruiseApplicationStatus';
import { Path } from './Path';
import { FormType } from '../Pages/CommonComponents/FormTitleWithNavigation';

const formDownloadProps = (formContext: FormContextFields) => {
  return {
    download: fileName(formContext?.type!),
    href: handleDownload(formContext?.getValues()!),
  };
};

export const DownloadButtonDefault = () => {
  const formContext = useContext(FormContext);
  return (
    <a
      {...formDownloadProps(formContext!)}
      className='form-page-option-button-default'
    >
      {' '}
      Pobierz{' '}
    </a>
  );
};

export const ResendButton = () => {
  const formContext = useContext(FormContext);
  return (
    <div
      onClick={() => formContext!.setReadOnly(false)}
      className='form-page-option-button-default'
    >
      {' '}
      Kopiuj
    </div>
  );
};

export const RefillBButton = () => {
  const location = extendedUseLocation();
  const navigate = useNavigate();
  return (
    <div
      onClick={() =>
        refillFormB(location?.state.cruiseApplication?.id).then((_) => {
          location!.state.cruiseApplication.status =
            CruiseApplicationStatus.FormBRequired;
          navigate(Path.Form, { state: location!.state, replace: true });
        })
      }
      className='form-page-option-button-default'
    >
      Cofnij do edycji
    </div>
  );
};

export const RefillCButton = () => {
  const location = extendedUseLocation();
  const navigate = useNavigate();
  return (
    <div
      onClick={() =>
        refillFormC(location?.state.cruiseApplication?.id).then((_) => {
          location!.state.cruiseApplication.status =
            CruiseApplicationStatus.Undertaken;
          navigate(Path.Form, { state: location!.state, replace: true });
        })
      }
      className='form-page-option-button-default'
    >
      Cofnij do edycji
    </div>
  );
};

const ConfirmSaveButton = () => {
  const formContext = useContext(FormContext);
  const _handleSave = handleSave();
  return (
    <div
      onClick={_handleSave}
      className={
        formContext?.type == FormType.A
          ? 'form-page-option-note-button-large'
          : 'form-page-option-button w-100'
      }
    >
      Potwierdź
    </div>
  );
};

const DownloadButton = () => {
  const formContext = useContext(FormContext);
  return (
    <a
      className={'form-page-option-note-button-small'}
      {...formDownloadProps(formContext!)}
    >
      <DownloadIcon />
    </a>
  );
};

const PrintButton = () => (
  <button onClick={handlePrint} className='form-page-option-note-button-large'>
    Drukuj
  </button>
);

export function SaveMenu() {
  const [savingStated, setSavingStarted] = useState(false);
  const formContext = useContext(FormContext);

  const CancelButton = () => (
    <div
      className={'form-page-option-note-button-small'}
      onClick={() => setSavingStarted(false)}
    >
      <CancelIcon />
    </div>
  );

  const SaveButton = () => {
    const onClickAction = () => setSavingStarted(true);
    return (
      <button
        onClick={onClickAction}
        className='form-page-option-button-default'
      >
        Zapisz
      </button>
    );
  };

  const NoteInput = () => {
    const formContext = useContext(FormContext);
    return (
      <input
        maxLength={100}
        {...formContext!.register('note')}
        placeholder={'Notatka'}
        className={'form-page-option-note-input'}
        type={'text'}
      />
    );
  };

  return {
    menu: () => (
      <>
        {formContext!.type === FormType.A && <NoteInput />}
        <ConfirmSaveButton />
        <PrintButton />
        <CancelButton />
      </>
    ),
    saveButton: SaveButton,
    enabled: savingStated,
  };
}
