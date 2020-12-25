import React, { Fragment, useContext } from "react";
import { RootStoreContext } from "../stores/rootStore";
import { Segment, Container, Header, Button } from "semantic-ui-react";
import { Link } from "react-router-dom";
import LoginForm from "../features/forms/LoginForm";
import { observer } from "mobx-react-lite";
import RegisterForm from "../features/forms/registerForm";

const Home = () => {
  const token = window.localStorage.getItem("jwt");
  const rootStore = useContext(RootStoreContext);
  const { user, isLoggedIn } = rootStore.userStore;
  const { openModal } = rootStore.modalStore;

  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
        <Header as="h1" inverted>
          Qlientel TEST new 
        </Header>

        {isLoggedIn && user && token ? (
          <Fragment>
            <Header as="h2" inverted content={`Welcome, ${user.displayName}`} />
            <Button as={Link} to={`/${user.role[0].toLowerCase()}/dashboard`} size="huge" inverted>
              myDashboard
            </Button>
          </Fragment>
        ) : (
          <Fragment>
            <Button
              onClick={() => openModal(<LoginForm />)}
              size="huge"
              inverted
            >
              Login
            </Button>
            <Button
              onClick={() => openModal(<RegisterForm />)}
              size="huge"
              inverted
            >
              Register
            </Button>
          </Fragment>
        )}
      </Container>
    </Segment>
  );
};

export default observer(Home);
