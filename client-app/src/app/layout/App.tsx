import React, { useState, useEffect, Fragment } from 'react';
import { Header, Icon, List, Container } from 'semantic-ui-react';
import axios from 'axios';
import { IDealerInfo } from '../models/dealerInfo';
import NavBar from '../../features/nav/NavBar';
import { DealersDashboard } from '../../features/dealers/dashboard/DealersDashboard';

const App = () => {

  const [dealerinfos, setDealerinfos] = useState<IDealerInfo[]>([])

  useEffect(() => {
    axios.get<IDealerInfo[]>('http://localhost:5000/api/dealerinfos')
      .then(response => {
        setDealerinfos(response.data)
      });
  }, [])

  return (
    <Fragment>
      <NavBar />
      <Container style={{ marginTop: '6em' }}>
        <DealersDashboard dealerinfos={dealerinfos} />
      </Container>
    </Fragment>
  );
  //}


}

export default App;
