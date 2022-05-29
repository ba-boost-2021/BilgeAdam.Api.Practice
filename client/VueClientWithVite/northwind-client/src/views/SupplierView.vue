<template>
  <div class="heading">
    <h3>Tedarikçi Yönetim Paneli</h3>
  </div>
  <Transition>
    <div v-if="isSuccess" class="alert alert-success">İşlem Başarılı :)</div>
  </Transition>
  <Transition>
    <div v-if="isFailed" class="alert alert-danger">İşlem Başarısız :(</div>
  </Transition>
  <div
    class="d-flex justify-content-center align-content-center"
    style="min-height: 500px !important"
  >
    <div v-if="loading" class="spinner-grow text-primary" role="status">
      <span class="sr-only">Loading...</span>
    </div>
    <div v-if="!loading" class="table-responsive">
      <table class="table table-striped" style="font-size: 0.8rem">
        <thead class="thead-dark">
          <tr>
            <th scope="col">Company Name</th>
            <th scope="col">Contact Name</th>
            <th scope="col">Contact Title</th>
            <th scope="col">Address</th>
            <th scope="col">Phone</th>
            <th scope="col">Fax</th>
            <th scope="col"></th>
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
            <td>
              <button
                @click="deleteSupplier(s.id)"
                class="btn btn-sm btn-outline-danger"
              >
                <i class="bi bi-trash"></i>
              </button>
            </td>
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
  <DeleteConfirm ref="deleteModal" @yes="deleteOk" />
</template>
<script>
import axios from "axios";
import DeleteConfirm from "../components/modals/DeleteConfirm.vue";
export default {
  data() {
    return {
      suppliers: [],
      totalCount: 0,
      loading: false,
      page: 1,
      count: 10,
      isSuccess: false,
      isFailed: false,
      selectedId: null,
    };
  },
  components: {
    DeleteConfirm,
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
      }, 1000);
    },
    deleteSupplier(id) {
      this.selectedId = id;
      this.$refs.deleteModal.open();
    },
    deleteOk() {
      axios
        .delete(`https://localhost:7000/api/supplier/delete/${this.selectedId}`)
        .then((response) => {
          if (response) {
            this.isSuccess = true;
            this.load();
          }
        })
        .catch((error) => {
          if (error) {
            this.isFailed = true;
          }
        })
        .finally(() => {
          setTimeout(() => {
            this.isSuccess = false;
            this.isFailed = false;
          }, 4000);
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
<style scoped>
.heading {
  color: gray;
  padding: 10px;
  margin-bottom: 15px;
}
/* we will explain what these classes do next! */
.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease;
}

.v-enter-from,
.v-leave-to {
  opacity: 0;
}
</style>