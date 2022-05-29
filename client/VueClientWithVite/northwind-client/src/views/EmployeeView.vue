<template>
  <div class="heading">
    <h3>Personel Yönetim Paneli</h3>
  </div>
  <div style="min-height: 500px !important">
    <div v-if="loading" class="alert alert-info">Yükleniyor...</div>
    <div v-else class="table-responsive">
      <table class="table table-striped" style="font-size: 0.6rem">
        <thead class="thead-dark">
          <tr>
            <th scope="col">First Name</th>
            <th scope="col">Last Name</th>
            <th scope="col">Title</th>
            <th scope="col">Hire Date</th>
            <th scope="col">Birth Date</th>
            <th scope="col">City</th>
            <th scope="col">Country</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="e in employees" :key="e.id">
            <td>{{ e.firstName }}</td>
            <td>{{ e.lastName }}</td>
            <td>{{ e.title }}</td>
            <td>{{ formatDate(e.hireDate) }}</td>
            <td>{{ formatDate(e.birthDate) }}</td>
            <td>{{ e.city }}</td>
            <td>{{ e.country }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>

  <div class="d-flex justify-content-center">
    <button
      @click="previus"
      class="btn btn-outline-info m-1"
      :disabled="page <= 1"
    >
      <i class="bi bi-arrow-left"></i>
    </button>
    <button
      @click="next"
      class="btn btn-outline-info m-1"
      :disabled="totalCount <= 0"
    >
      <i class="bi bi-arrow-right"></i>
    </button>
  </div>
</template>
<script>
import axios from "axios";
import {format, parseISO} from "date-fns";
export default {
  data() {
    return {
      employees: [],
      totalCount: 0,
      loading: false,
      page: 1,
      count: 10,
    };
  },
  mounted() {
    this.load();
  },
  methods: {
    load() {
      this.loading = true;
      setTimeout(() => {
        axios
          .get(
            `https://localhost:7000/api/employee/list?count=${this.count}&page=${this.page}`
          )
          .then((response) => {
            this.employees = response.data.data;
            this.totalCount = response.data.totalCount;
          })
          .catch((error) => {
            //TODO: handle
          })
          .finally(() => {
            this.loading = false;
            //TODO: handle, son olarak yapılmasını istediğin şeyler
          });
      }, 1000);
    },

    next() {
      if (this.totalCount > 0) {
        this.page++;
        this.load();
      }
    },
    previus() {
      if (this.page > 1) {
        this.page--;
        this.load();
      }
    },
    formatDate(date){
      return format(parseISO(date),"dd/MM/yyyy");
    }
  },
};
</script>
<style scoped>
.heading {
  color: gray;
  padding: 10px;
  margin-bottom: 15px;
}
</style>