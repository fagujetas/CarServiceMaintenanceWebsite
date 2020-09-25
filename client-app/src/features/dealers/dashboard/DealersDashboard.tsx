import React from 'react'
import { Grid } from 'semantic-ui-react'
import { IDealerInfo } from '../../../app/models/dealerInfo'
import { DealersList } from './DealersList'
import { DealerDetails } from '../details/DealerDetails'
import { ICityInfo } from '../../../app/models/cityInfo'
import { SetAppointmentForm } from '../../carowner/SetAppointmentForm'
import { IAppointmentInfo } from '../../../app/models/appointmentInfo'

interface IProps {
    dealerinfos: IDealerInfo[];
    cityinfos: ICityInfo[];
    selectDealer: (id: string) => void;
    selectedDealer: IDealerInfo | null;
    appointmentMode: boolean;
    setAppointmentMode: (appointmentMode: boolean) => void;
    createAppointment: (appointment: IAppointmentInfo) => void;
    appointment:IAppointmentInfo;
    submitting: boolean;
}

export const DealersDashboard: React.FC<IProps> = ({ 
    dealerinfos, 
    cityinfos, 
    selectDealer, 
    selectedDealer,
    appointmentMode,
    setAppointmentMode,
    createAppointment,
    appointment,
    submitting
}) => {
    return (
        <Grid>
            <Grid.Column width={10}>
                <DealersList
                    dealerinfos={dealerinfos}
                    cityinfos={cityinfos}
                    selectDealer={selectDealer}
                />
            </Grid.Column>
            <Grid.Column width={6}>
                {/* {selectedDealer && !appointmentMode && (<DealerDetails dealer={selectedDealer} setAppointmentMode={setAppointmentMode} />) } */}
                {selectedDealer && <DealerDetails setAppointment={createAppointment} dealer={selectedDealer} setAppointmentMode={setAppointmentMode} selectDealer={selectDealer} /> }
                {appointmentMode && 
                    <SetAppointmentForm 
                        key={0}
                        appointment={appointment}
                        setAppointmentMode={setAppointmentMode}
                        createAppointment={createAppointment}
                        submitting={submitting}
                    />
                    }
                
            </Grid.Column>
        </Grid>
    )
}
