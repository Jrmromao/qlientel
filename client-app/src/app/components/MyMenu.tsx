import React, { useState, useContext, useEffect } from "react";
import {
  Menu,
  MenuItemProps,
  Grid,

} from "semantic-ui-react";
import { Link } from "react-router-dom";
import { RootStoreContext } from "../stores/rootStore";
import { observer } from "mobx-react-lite";
import { AppMedia } from "../constants/MediaScreen";

const MyMenu: React.FC = () => {
  const { MediaContextProvider } = AppMedia;

  const [activeItem, setActiveItem] = useState("home");
  const rootStore = useContext(RootStoreContext);
  const { user } = rootStore.userStore;

  const handleItemClick = (
    event: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
    data: MenuItemProps
  ) => {
    setActiveItem(data.name!);
  };

  useEffect(() => {
    setActiveItem(window.location.pathname);
  }, [setActiveItem]);

  if (user?.role[0] !== "User")
    return (
      <MediaContextProvider>
        <Grid centered columns="1">
          <Grid.Column>
            <Menu pointing secondary fluid>
              <Menu.Item
                name="/home"
                active={activeItem === "/home"}
                onClick={handleItemClick}
                as={Link}
                to={`/home`}
                content="Home"
              />
              <Menu.Item
                name="/dashboard"
                active={activeItem === "/dashboard"}
                onClick={handleItemClick}
                as={Link}
                to={`/dashboard`}
              />

              {user?.role[0] === "Admin" && (
                <Menu.Item
                  name="/manage-policies"
                  active={activeItem === "/manage-policies"}
                  onClick={handleItemClick}
                  as={Link}
                  to={"/manage-policies"}
                />
              )}

              {user?.role[0] === "Admin" && (
                <Menu.Item
                  name="/company-directory"
                  active={activeItem === "/company-directory"}
                  onClick={handleItemClick}
                  as={Link}
                  to={"/company-directory"}
                />
              )}
              {user?.role[0] === "Admin" && (
                <Menu.Item
                  name="/employee-directory"
                  active={activeItem === "/employee-directory"}
                  onClick={handleItemClick}
                  as={Link}
                  to={"/employee-directory"}
                />
              )}

              {/* manager */}
              {user?.role[0] === "Manager" && (
                <Menu.Item
                  name="/employee-directory"
                  active={activeItem === "/employee-directory"}
                  onClick={handleItemClick}
                  as={Link}
                  to={"/employee-directory"}
                />
              )}
            </Menu>
          </Grid.Column>
        </Grid>
      </MediaContextProvider>
    );
  else
    return (
      <MediaContextProvider>
        <Grid   columns="1">
          <Grid.Column>
            <Menu pointing secondary fluid>
              <Menu.Item
                name="/user/dashboard/"
                active={activeItem === "/user/dashboard/"}
                onClick={handleItemClick}
                as={Link}
                to={`/user/dashboard/`}
                content="Home"
              />
                   <Menu.Item
                name="/Manage Documents"
                active={activeItem === "/Manage Documents"}
                onClick={handleItemClick}
                as={Link}
                to={`/Manage Documents`}
                content="Manage Documents"
              />
            </Menu>
          </Grid.Column>
        </Grid>
      </MediaContextProvider>
    );
};

export default observer(MyMenu);
