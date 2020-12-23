import React from "react";
import { Button, Segment, Header, Icon } from "semantic-ui-react";
import { history } from "../../..";

export const NotFound = () => {
  return (
    <Segment placeholder className='not-found-page'>



      <Header icon>

      <Header color='teal'>

        <h1>404</h1>
      </Header>

        <Icon name="search" />
        Oops - we've looked everywhere but couldn't find this.
      </Header>
      <Segment.Inline>
        <Button onClick={() => history.goBack()} primary>
          Go Back
        </Button>
      </Segment.Inline>
    </Segment>
  );
};
