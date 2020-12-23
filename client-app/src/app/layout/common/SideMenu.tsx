import React, { useState, useContext } from "react";
import { Menu, MenuItemProps } from "semantic-ui-react";
import { Link } from "react-router-dom";
import { observer } from "mobx-react-lite";
import { RootStoreContext } from "../../stores/rootStore";
import TextIcon from "../../components/TextIcon";

interface IProps {
  children: any;
}

const SideMenu: React.FC<IProps> = ({ children }) => {
  const rootStore = useContext(RootStoreContext);
  const { sideMenuVisible } = rootStore.menuBarStore;
  const { user } = rootStore.userStore;
  const [activeItem, setActiveItem] = useState("dashboard");

  const handleItemClick = (
    event: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
    data: MenuItemProps
  ) => setActiveItem(data.name!);

  const getAdminMenu = () => {
    return (
      <Menu
        fixed="left"
        borderless
        className={(sideMenuVisible ? "small-side" : "") + " side "}
        vertical
      >
        <Menu.Item
          as={Link}
          to={"/home"}
          name="dashboard"
          active={activeItem === "dashboard"}
          onClick={handleItemClick}
        >
          <div style={{ color: "#E9E9E9" }}>LOGO</div>
        </Menu.Item>

        <Menu.Item
          as={Link}
          to={`/${user?.role}/dashboard`}
          name="dashboard"
          active={activeItem === "dashboard"}
          onClick={handleItemClick}
        >
          <TextIcon
            toolTipContent={"Profile"}
            hideText={sideMenuVisible}
            inverted={true}
            size="small"
            colorTxt="#E9E9E9"
            name="dashboard"
          >
            Dashboard
          </TextIcon>
        </Menu.Item>

        <Menu.Item
          as={Link}
          to={"/manage-customer"}
          name="/manage-customer"
          active={activeItem === "/manage-customer"}
          onClick={handleItemClick}
        >
          <TextIcon
            toolTipContent={"Profile"}
            hideText={sideMenuVisible}
            inverted={true}
            size="small"
            colorTxt="#E9E9E9"
            name="industry"
          >
            Manage Customers
          </TextIcon>
        </Menu.Item>
        <Menu.Item
          as={Link}
          to={"/manage-user"}
          name="/manage-user"
          active={activeItem === "/manage-user"}
          onClick={handleItemClick}
        >
          <TextIcon
            toolTipContent="industry"
            hideText={sideMenuVisible}
            size="small"
            inverted={true}
            colorTxt="#E9E9E9"
            name="users"
          >
            Manage Users
          </TextIcon>
        </Menu.Item>

        <Menu.Item
          as={Link}
          to={"/profile"}
          name="profile"
          active={activeItem === "profile"}
          onClick={handleItemClick}
        >
          <TextIcon
            toolTipContent="Profile"
            hideText={sideMenuVisible}
            size="small"
            inverted={true}
            colorTxt="#E9E9E9"
            name="folder"
          >
            Manage Companies
          </TextIcon>
        </Menu.Item>
      </Menu>
    );
  };

  return (
    <div>
      <div className="parent">
        <div className={(sideMenuVisible ? "small-side " : "") + "side"}>
          {getAdminMenu()}
        </div>
        <div className={(sideMenuVisible ? "small-content " : "") + "content"}>
          {children}
        </div>
      </div>
    </div>
  );
};

export default observer(SideMenu);
