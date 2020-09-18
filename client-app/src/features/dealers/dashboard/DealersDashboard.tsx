import React from 'react'
import { Grid } from 'semantic-ui-react'
import { IDealerInfo } from '../../../app/models/dealerInfo'
import { DealersList } from './DealersList'
import { DealerDetails } from '../details/DealerDetails'
import { ICityInfo } from '../../../app/models/cityInfo'
import { SetAppointmentForm } from '../../carowner/SetAppointmentForm'

interface IProps {
    dealerinfos: IDealerInfo[];
    cityinfos: ICityInfo[];
    selectDealer: (id: string) => void;
    selectedDealer: IDealerInfo | null;
}

export const DealersDashboard: React.FC<IProps> = ({ dealerinfos, cityinfos, selectDealer, selectedDealer }) => {
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
                {selectedDealer && <DealerDetails dealer={selectedDealer} /> }
                <SetAppointmentForm />
            </Grid.Column>
        </Grid>
    )
}
