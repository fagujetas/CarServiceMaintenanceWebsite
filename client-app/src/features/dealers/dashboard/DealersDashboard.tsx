import React from 'react'
import { Grid, List } from 'semantic-ui-react'
import { Interface } from 'readline'
import { IDealerInfo } from '../../../app/models/dealerInfo'
import { DealersList } from './DealersList'
import { DealerDetails } from '../details/DealerDetails'

interface IProps {
    dealerinfos: IDealerInfo[]
}

export const DealersDashboard:React.FC<IProps> = ({dealerinfos}) => {
    return (
        <Grid>
            <Grid.Column width={10}>
                <DealersList dealerinfos={dealerinfos} />
            </Grid.Column>
            <Grid.Column width={6}>
                <DealerDetails dealerinfos={dealerinfos} />
            </Grid.Column>
        </Grid>
    )
}
