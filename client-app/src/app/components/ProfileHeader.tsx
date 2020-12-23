
import React, { Fragment, useContext } from "react";
// import { RootStoreContext } from "../stores/rootStore";
import TopMenu from "../layout/common/TopMenu";
import { Grid, List } from "semantic-ui-react";
import ProfilePhotoText from "./ProfilePhotoText";
// import TextIcon from "./TextIcon";
import { observer } from "mobx-react-lite";
// import {} from 'react-social-icons'

  const ProfileHeader = () => {
  // const rootStore = useContext(RootStoreContext);
  // const { user } = rootStore.userStore;

  return (
    <Fragment>
      <TopMenu />
      <div className="profileTopBox">
        <Grid  className="">
          <Grid.Column width={15}>
            <ProfilePhotoText
              src="https://react.semantic-ui.com/images/avatar/large/steve.jpg"
              size="small"
            >
              <List>
                {/* <List.Item>
                  <TextIcon inverted={false} size="larger" name="user">
                    <h4> {user?.displayName}</h4>{" "}
                  </TextIcon>
                </List.Item>
                <List.Item>
                  <TextIcon inverted={false} size="larger" name="map pin">
                    <h4>{user?.username}</h4>{" "}
                  </TextIcon>
                </List.Item>
                <List.Item>
                  <TextIcon inverted={false} size="larger" name="legal">
                    <h4>Role</h4>
                  </TextIcon>
                </List.Item>
                <List.Item>
                  <TextIcon
                    inverted={false}
                    size="larger"
                    name="legal"
                  ></TextIcon>
                </List.Item> */}
              </List>
            </ProfilePhotoText>
          </Grid.Column>
     
        </Grid>
      </div>
    </Fragment>
  );
};


export default observer(ProfileHeader)