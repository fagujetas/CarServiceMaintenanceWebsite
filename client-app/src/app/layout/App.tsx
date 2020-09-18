import React, { useState, useEffect, Fragment } from 'react';
import { Container } from 'semantic-ui-react';
import axios from 'axios';
import { IDealerInfo } from '../models/dealerInfo';
import { NavBar } from '../../features/nav/NavBar';
import { DealersDashboard } from '../../features/dealers/dashboard/DealersDashboard';
import { ICityInfo } from '../models/cityInfo';

const App = () => {

  const [dealerinfos, setDealerinfos] = useState<IDealerInfo[]>([]);
  const [cityinfos, setCityInfos] = useState<ICityInfo[]>([]);
  const [selectedDealer, setSelectedDealer] = useState<IDealerInfo | null>(null);

  const handleSelectedDealer = (id: string) => {
    setSelectedDealer(dealerinfos.filter(d => d.id === id)[0])
  }

  useEffect(() => {
    axios.get<IDealerInfo[]>('http://localhost:5000/api/dealerinfos')
      .then(response => {
        setDealerinfos(response.data)
      });
  }, [])

  //https://localhost:5001/api/dealerinfos/searchallcities
  useEffect(() => {
    axios.get<ICityInfo[]>('http://localhost:5000/api/dealerinfos/searchallcities')
      .then(response => {
        setCityInfos(response.data)
      });
  }, [])

  return (
    <Fragment>
      <NavBar cityinfos={cityinfos} />
      <Container style={{ marginTop: '6em' }}>
        <DealersDashboard 
            dealerinfos={dealerinfos} 
            cityinfos={cityinfos}
            selectDealer={handleSelectedDealer} 
            selectedDealer={selectedDealer}
        />
      </Container>
    </Fragment>
  );
  //}


}

export default App;
