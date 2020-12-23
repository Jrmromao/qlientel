import React from "react";
import { Menu } from "semantic-ui-react";
import { observer } from "mobx-react-lite";

const Footer: React.FC = () => {
  return (
    <Menu fixed="bottom">
      <Menu.Item position="right">
        All Rights Reserved {new Date().getFullYear()}
      </Menu.Item>
    </Menu>
  );
};

export default observer(Footer);
