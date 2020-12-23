import React, { useContext } from "react";
import { Image, Label, Menu, Dropdown, Icon } from "semantic-ui-react";
import Notification from "./Notification";
import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import { RootStoreContext } from "../../stores/rootStore";
interface IProps {}

const TopMenu: React.FC<IProps> = () => {
  const rootStore = useContext(RootStoreContext);
  const { user, logout } = rootStore.userStore;

  return (
    <Menu className="top-menu">
      <Menu.Item className="no-border" onClick={() => {}}>
        <Icon name="bars" />
      </Menu.Item>

      <Menu.Menu position="right">
        <Menu.Item className="no-border" position="right">
          <Notification />

          <Label
            className="label-on-corner"
            color="teal"
            size={"mini"}
            floating
            circular
          >
            1
          </Label>
        </Menu.Item>
        {user && (
          <Menu.Item position="right">
            <Image
              circular
              size={"mini"}
              src="https://react.semantic-ui.com/images/avatar/large/steve.jpg"
            />
            <br />
            <Dropdown text={user.displayName} simple direction="left">
              <Dropdown.Menu style={{ marginTop: 20 }}>
                <Dropdown.Item
                  as={Link}
                  to={`/home`}
                  text="My profile"
                  icon="user"
                />
                <Dropdown.Item onClick={logout} text="Logout" icon="power" />
              </Dropdown.Menu>
            </Dropdown>
          </Menu.Item>
        )}
      </Menu.Menu>
    </Menu>
  );
};

export default observer(TopMenu);
