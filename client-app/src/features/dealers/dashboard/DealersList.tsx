import React from 'react'
import { Item, Image, Button, Label, Segment } from 'semantic-ui-react'
import { IDealerInfo } from '../../../app/models/dealerInfo'


interface IProps {
    dealerinfos: IDealerInfo[]
}

export const DealersList: React.FC<IProps> = ({ dealerinfos }) => {
    return (
        <Segment clearing>
            <Item.Group divided>
                {dealerinfos.map(dealerinfo => (
                    <Item key={dealerinfo.id}>
                        <Item.Content>
                            <Item.Header as='a'>{dealerinfo.name}</Item.Header>
                            <Item.Meta>{dealerinfo.address1}</Item.Meta>
                            <Item.Meta>{dealerinfo.postCode} {dealerinfo.city}</Item.Meta>
                            {/* <Item.Description>
                                <div>Contact Person</div>
                                <div>Number</div>
                            </Item.Description> */}
                            <Item.Extra>
                                <Button floated='right' content='View' color='teal' />
                                <Label basic content='Category' />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}
