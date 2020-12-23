import React, { useContext } from "react";
import { Menu, Container, Button, Dropdown } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
// import {  NavLink } from "react-router-dom";
import { RootStoreContext } from "../../stores/rootStore";
import { Link } from "react-router-dom";

// here I could pass the parameter just as 'props'
const NavBar: React.FC = () => {
  const rootStore = useContext(RootStoreContext);
  const { logout, user } = rootStore.userStore;

  return (
    <Menu fixed="top" inverted style={{ backgroundColor: "silver" }}>
      <Container>
        {/* <Menu.Item name="Dashboard" as={Link}  to='/dashboard'/> */}
        {user && (
          <Menu.Item position="right">
            <Dropdown pointing="top left" text={user.displayName}>
              <Dropdown.Menu>
                <Dropdown.Item
                  as={Link}
                  to={`/dashboard`}
                  text="My Dashboard"
                  icon="user"
                />
                <Dropdown.Item onClick={logout} text="Logout" icon="power" />
              </Dropdown.Menu>
            </Dropdown>
          </Menu.Item>
        )}
      </Container>
    </Menu>
  );
};

export default observer(NavBar);
