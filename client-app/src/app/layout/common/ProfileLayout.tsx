import React, { Fragment } from "react";
import MyMenu from "../../components/MyMenu";
import ProfileHeader from '../../components/ProfileHeader'
import { observer } from "mobx-react-lite";
import { Container } from "semantic-ui-react";

interface IProps {
  children: any;
}
const ProfileLayout: React.FC<IProps> = ({ children }) => {
  return (
    <Fragment>
      <ProfileHeader/>
      <Container>
        <MyMenu />
        {children}
      </Container>
    </Fragment>
  );
};

export default observer(ProfileLayout);
