<template>
  <div class="mt-5 row justify-content-center">
    <div class="col-4">
      <ul class="nav nav-pills nav-justified mb-3" id="ex1" role="tablist">
        <li class="nav-item">
          <a class="nav-link active" role="tab" @click="previous">Login</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" role="tab" @click="next">Register</a>
        </li>
      </ul>

      <div class="tab-content">
        <div class="tab-pane fade show active" v-if="step == 1">
          <div class="form-outline mb-4">
            <label class="form-label" for="loginName">Email</label>
            <input
              type="email"
              id="loginName"
              class="form-control"
              v-model="mail"
            />
          </div>

          <div class="form-outline mb-4">
            <label class="form-label" for="loginPassword">Password</label>
            <input
              type="password"
              id="loginPassword"
              class="form-control"
              v-model="password"
            />
          </div>

          <div class="row mb-4">
            <div class="col-md-6 d-flex justify-content-center">
              <div class="form-check mb-3 mb-md-0">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value=""
                  id="loginCheck"
                  checked
                />
                <label class="form-check-label" for="loginCheck">
                  Remember me
                </label>
              </div>
            </div>

            <div class="col-md-6 d-flex justify-content-center">
              <a href="#!">Forgot password?</a>
            </div>
          </div>

          <button class="btn btn-primary btn-block mb-4 w-100" @click="signIn">
            Sign in
          </button>

          <div class="text-center">
            <p>Not a member? <a href="#" @click="next">Register</a></p>
          </div>
        </div>
        <div v-if="step == 2" class="tab-panel show active fade">
          <div class="form-outline mb-4">
            <input type="text" id="registerName" class="form-control" />
            <label class="form-label" for="registerName">Name</label>
          </div>

          <div class="form-outline mb-4">
            <input type="text" id="registerUsername" class="form-control" />
            <label class="form-label" for="registerUsername">Username</label>
          </div>

          <div class="form-outline mb-4">
            <input type="email" id="registerEmail" class="form-control" />
            <label class="form-label" for="registerEmail">Email</label>
          </div>

          <div class="form-outline mb-4">
            <input type="password" id="registerPassword" class="form-control" />
            <label class="form-label" for="registerPassword">Password</label>
          </div>

          <div class="form-outline mb-4">
            <input
              type="password"
              id="registerRepeatPassword"
              class="form-control"
            />
            <label class="form-label" for="registerRepeatPassword"
              >Repeat password</label
            >
          </div>

          <div class="form-check d-flex justify-content-center mb-4">
            <input
              class="form-check-input me-2"
              type="checkbox"
              value=""
              id="registerCheck"
              checked
              aria-describedby="registerCheckHelpText"
            />
            <label class="form-check-label" for="registerCheck">
              I have read and agree to the terms
            </label>
          </div>

          <button class="btn btn-primary btn-block mb-3 w-100">Sign in</button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import session from "../helpers/session.js";
export default {
  name: "login",
  data() {
    return {
      mail: null,
      password: null,
      step: 1,
    };
  },
  methods: {
    signIn() {
      let data = {
        Mail: this.mail,
        Password: this.password,
      };
      this.$ajax
        .post("https://localhost:7000/api/authentication/login", data)
        .then((response) => {
          if (response) {
            session.setToken(response.data.token, response.data.expireAt);
            this.$router.push("/supplier");
          }
        });
    },
    next() {
      this.step = 2;
    },
    previous() {
      this.step = 1;
    },
  },
};
</script>
