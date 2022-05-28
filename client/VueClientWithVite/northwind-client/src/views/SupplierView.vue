<template>
  <div class="heading">
    <h3>Tedarikçi Yönetim Paneli</h3>
  </div>
  <div v-if="loading" class="alert alert-info">Yükleniyor...</div>
  <div v-else class="table table-striped table-sm">
    <thead class="thead-dark">
      <tr>
        <th scope="col">Company Name</th>
        <th scope="col">Contact Name</th>
        <th scope="col">Contact Title</th>
        <th scope="col">Address</th>
        <th scope="col">Phone</th>
        <th scope="col">Fax</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="s in suppliers" :key="s.id">
        <td>{{ s.companyName }}</td>
        <td>{{ s.contactName }}</td>
        <td>{{ s.title }}</td>
        <td>{{ s.address }}</td>
        <td>{{ s.phone }}</td>
        <td>{{ s.fax }}</td>
      </tr>
    </tbody>
  </div>
  <div class="row justify-content-center">
    <button @click="previus" class="btn btn-outline-warning w-25" :disabled="page <= 1">
      <i class="bi bi-arrow-left"></i>
    </button>
    <button @click="next" class="btn btn-outline-warning w-25" :disabled="totalCount <= 0">
      <i class="bi bi-arrow-right"></i>
    </button>
  </div>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      suppliers: [],
      totalCount: 0,
      loading: false,
      page: 1,
      count: 10,
    };
  },
  mounted() {
    this.loading = true;
    setTimeout(() => {
      this.load();
    }, 3000);
  },
  methods: {
    load() {
      axios
        .get(
          `https://localhost:7000/api/supplier/list?count=${this.count}&page=${this.page}`
        )
        .then((response) => {
          this.suppliers = response.data.data;
          this.totalCount = response.data.totalCount;
        })
        .catch((error) => {
          //TODO: handle
        })
        .finally(() => {
          this.loading = false;
          //TODO: handle, son olarak yapılmasını istediğin şeyler
        });
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
  },
};
</script>
<style>
</style>