import { SimpleInfoContextWrapperSingleField } from '@components/SimpleInfoContextWrapperSingleField';
import { CruiseApplicationContext } from '@contexts/CruiseApplicationContext';
import { CruiseApplication } from '../../../../types/CruiseApplication';

export const SimpleInfoWrapperSingleFieldCruiseApplication = (props: {
    title: string,
    selector: keyof CruiseApplication
}) =>
    <SimpleInfoContextWrapperSingleField<CruiseApplication> context={CruiseApplicationContext} {...props} />;