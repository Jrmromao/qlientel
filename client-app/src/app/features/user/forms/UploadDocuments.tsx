import { observer } from "mobx-react-lite";
import React, { useState } from "react";
import { Grid, Table } from "semantic-ui-react";
import UploadWidget from "../../../common/upload/UploadWidget";
import ProfileLayout from "../../../layout/common/ProfileLayout";

interface IProps {}
const UploadDocuments: React.FC<IProps> = ({}) => {
  const [files, setFiles] = useState<any[]>([]);

  return (
    <div>
      <Grid columns="2">
        <Grid.Column>
          <UploadWidget setFiles={setFiles} />
        </Grid.Column>
        <Grid.Column >
    
          <Table celled striped>
            <Table.Header>
              <Table.Row>
                <Table.HeaderCell>Document Name</Table.HeaderCell>
                <Table.HeaderCell>Action</Table.HeaderCell>
              </Table.Row>
            </Table.Header>
            <Table.Body>
              {files.map((e, i) => (
                <Table.Row key={i}>
                  <Table.Cell>{e.name}</Table.Cell>

                  <Table.Cell></Table.Cell>
                </Table.Row>
              ))}
            </Table.Body>
          </Table>
        </Grid.Column>
      </Grid>

      <br />
      <br />
      <br />
      <br />
      <br />
    </div>
  );
};

export default observer(UploadDocuments);
