import React, { useEffect, useRef, useState } from 'react'
import { Item, Button, Label, Segment, Dropdown } from 'semantic-ui-react'
import { IDealerInfo } from '../../../app/models/dealerInfo'
import { ICityInfo } from '../../../app/models/cityInfo'
import axios from 'axios';


interface IProps {
    dealerinfos: IDealerInfo[];
    cityinfos: ICityInfo[];
    selectDealer: (id: string) => void;
}

// function updateDealersListByCity(e: string) {
//     const city = e;
//     console.log(`selected city: ${city}`);
// }

export const DealersList: React.FC<IProps> = ({ dealerinfos, cityinfos, selectDealer }) => {

    const cArr = useRef(null);
    const [data, setData] = useState<IDealerInfo[]>([]);

    useEffect(() => {
        setData(dealerinfos);
    }, [dealerinfos]);

    useEffect(() => {
        cArr.current = cityinfos.map(cityinfo => (
            { key: cityinfo, value: cityinfo, text: cityinfo, name: cityinfo }
        ));
    }, [cityinfos]);

    function updateDealersListByCity(e: string) {
        const city = e;

        axios.get<IDealerInfo[]>(`http://localhost:5000/api/dealerinfos/searchdealersbycity/${city}`)
            .then(response => {
                setData(response.data)
            });
    }

    return (
        <Segment clearing>
            <Item.Group divided>
                <Dropdown
                    placeholder='Click here to filter list by City...'
                    fluid
                    search
                    selection
                    options={cArr.current}
                    name={cArr.current}
                    onChange={(e) => { updateDealersListByCity(e.currentTarget.textContent) }}
                />
            </Item.Group>
            <Item.Group divided>
                {data.map(dealerinfo => (
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
                                <Button 
                                    onClick={() => selectDealer(dealerinfo.id)}
                                    floated='right' 
                                    content='View' 
                                    color='teal' 
                                />
                                <Label basic content='Category' />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
            {/* <Item.Group divided>
                {dealerinfos.map(dealerinfo => (
                    <Item key={dealerinfo.id}>
                        <Item.Content>
                            <Item.Header as='a'>{dealerinfo.name}</Item.Header>
                            <Item.Meta>{dealerinfo.address1}</Item.Meta>
                            <Item.Meta>{dealerinfo.postCode} {dealerinfo.city}</Item.Meta>
                            {/* <Item.Description>
                                <div>Contact Person</div>
                                <div>Number</div>
                            </Item.Description> /}
                            <Item.Extra>
                                <Button floated='right' content='View' color='teal' />
                                <Label basic content='Category' />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group> */}
        </Segment>
    );
}
