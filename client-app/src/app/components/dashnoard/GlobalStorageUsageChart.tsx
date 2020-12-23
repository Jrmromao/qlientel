import React from 'react'
import { Header, Image, Segment } from 'semantic-ui-react'
import g1 from '../../../assets/g1.png'
const GlobalStorageUsageChart = () => {
    return (
      <Segment color="teal" className='dashboard-chart-segment'>
        <Header content="Global Storage Usage" />
        <Image src={g1} size="medium" />
      </Segment>
    );
}

export default GlobalStorageUsageChart
