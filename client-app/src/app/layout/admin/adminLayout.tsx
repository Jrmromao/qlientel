import React from "react";
import SideMenu from "../common/SideMenu";
import TopMenu from "../common/TopMenu";
import { observer } from "mobx-react-lite";

interface IProps {
  children: any;
}
const AdminLayout: React.FC<IProps> = ({ children }) => {
  return (
    <div className='margin-left'>
      <TopMenu/>
      <div className="main-content">
        <SideMenu>{children}</SideMenu>
      </div>
    </div>
  );
};

export default observer(AdminLayout);
