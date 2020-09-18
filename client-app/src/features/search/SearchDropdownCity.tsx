import React, { useEffect, useRef } from 'react';
import { Dropdown } from 'semantic-ui-react';
import { ICityInfo } from '../../app/models/cityInfo';

interface IProps {
    cityinfos: ICityInfo[]
}

function updateDealersListByCity(e: string)
{
    const city = e;
    console.log(`selected city: ${city}`);
}

export const SearchDropdownCity: React.FC<IProps> = ({ cityinfos }) => {

    const cArr = useRef(null);

    useEffect(() => {

        cArr.current = cityinfos.map(cityinfo => (
            { key: cityinfo, value: cityinfo, text: cityinfo, name: cityinfo }
        ));
    }, [cityinfos]);

    return (
        <Dropdown
            placeholder='Select City'
            fluid
            search
            selection
            options={cArr.current}
            name={cArr.current}
            onChange={(e) => {updateDealersListByCity(e.currentTarget.textContent)}}
        />
    )
}
