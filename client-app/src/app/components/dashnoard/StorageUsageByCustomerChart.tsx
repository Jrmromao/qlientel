import React from 'react'
import { Header, Image, Segment } from 'semantic-ui-react'
import g2 from '../../../assets/g2.png'
const StorageUsageByCustomerChart = () => {
    return (
      <Segment color="teal">
        <Header content="Storage Usage by Customer" />
        <Image src={g2} size='medium' />

      </Segment>
    );
}

export default StorageUsageByCustomerChart
