import { useLocation } from 'react-router-dom';
import { CruiseApplication } from '@types/CruiseApplication';

const cruiseApplicationFromLocation = () => {
    const location = useLocation();
    return location?.state?.cruiseApplication as CruiseApplication;
};

export default cruiseApplicationFromLocation;