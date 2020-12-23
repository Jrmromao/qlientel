import React, { useState, useEffect, useContext } from "react";
import { Segment, Dropdown, Table, Icon } from "semantic-ui-react";

import { RootStoreContext } from "../stores/rootStore";

import { format } from "date-fns";
import ProfileLayout from "../layout/admin/ProfileLayout";
import UploadWidget from "../common/upload/UploadWidget";
import UploadDocuments from "../features/user/forms/UploadDocuments";

const EmployeeList: React.FC = () => {
  const rootStore = useContext(RootStoreContext);
  const { user } = rootStore.userStore;
  const { loadEmployeesData, employeesData } = rootStore.manageEmployeeStore;
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadEmployeesData(user!).then(() => setLoading(false));
  }, [loadEmployeesData, user]);

  return (
    <ProfileLayout>
      {/* <Segment loading={loading}>
        <br />
        <Dropdown
          clearable
          selection
          search
          placeholder="Search for a..."
          fluid
          basic
          noResultsMessage="Try another search."
          options={[]}
        />
        <br /> 
      </Segment> */}
      <Segment>
{/* <UploadDocuments/> */}
</Segment>

    </ProfileLayout>
  );
};

export default EmployeeList;
