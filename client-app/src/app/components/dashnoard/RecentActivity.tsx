import { observer } from "mobx-react-lite";
import React, { Fragment } from "react";
import { Segment, Header, Feed, Button } from "semantic-ui-react";

 

const RecentActivity = () => {
  return (
    <Fragment>
      <Segment color="blue" className="recent-activity-segment">
        <Header content="Recent Activity" />

        <Feed size='large'>
          <Feed.Event >
            <Feed.Label image="https://react.semantic-ui.com/images/avatar/small/steve.jpg" />
            <Feed.Content>
              <Feed.Summary
                content="You registered a new customer: Data Storm"
                date="yesterday"
              />
            </Feed.Content>
          </Feed.Event>
          <br />
          <Feed.Event>
            <Feed.Label image="https://react.semantic-ui.com/images/avatar/small/jenny.jpg" />
            <Feed.Content>
              <Feed.Summary
                content="Jenny has completed her induction tasks."
              />
              
      
              <Feed.Date>3 days ago</Feed.Date>
            </Feed.Content>
          </Feed.Event>
        </Feed>
      </Segment>
    </Fragment>
  );
};

export default observer(RecentActivity);
