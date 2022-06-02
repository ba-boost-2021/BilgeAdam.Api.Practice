<template>
  <div
    class="modal fade"
    id="newModal"
    tabindex="-1"
    aria-labelledby="newModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="newModalLabel">
            Yeni Tedarikçi Ekleme Ekranı
          </h5>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          <div v-if="hasError" class="alert alert-warning m-1">
            Veriler doğrulanamadı...
          </div>
          <div class="row">
            <div class="col">
              <div class="mb-1">
                <label for="companyName" class="form-label">Company Name</label>
                <input
                  type="text"
                  class="form-control form-control-sm"
                  id="companyName"
                  v-model="companyName"
                />
              </div>
              <div class="mb-1">
                <label for="contactName" class="form-label">Contact Name</label>
                <input
                  type="text"
                  class="form-control form-control-sm"
                  id="contactName"
                  v-model="contactName"
                />
              </div>
              <div class="mb-1">
                <label for="contactTitle" class="form-label"
                  >Contact Title</label
                >
                <input
                  type="text"
                  class="form-control form-control-sm"
                  id="contactTitle"
                  v-model="contactTitle"
                />
              </div>
              <div class="mb-1">
                <label for="address" class="form-label">Address</label>
                <textarea
                  type="text"
                  class="form-control form-control-sm"
                  id="address"
                  v-model="address"
                />
              </div>
            </div>
            <div class="col">
              <div class="mb-1">
                <label for="city" class="form-label">City</label>
                <input
                  type="text"
                  class="form-control form-control-sm"
                  id="city"
                  v-model="city"
                />
              </div>
              <div class="mb-1">
                <label for="region" class="form-label">Region</label>
                <input
                  type="text"
                  class="form-control form-control-sm"
                  id="region"
                  v-model="region"
                />
              </div>
              <div class="mb-1">
                <label for="postalCode" class="form-label">Postal Code</label>
                <input
                  type="text"
                  class="form-control form-control-sm"
                  id="postalCode"
                  v-model="postalCode"
                />
              </div>
              <div class="mb-1">
                <label for="country" class="form-label">Country</label>
                <input
                  type="text"
                  class="form-control form-control-sm"
                  id="country"
                  v-model="country"
                />
              </div>
              <div class="mb-1">
                <label for="phone" class="form-label">Phone</label>
                <input
                  type="text"
                  class="form-control form-control-sm"
                  id="phone"
                  v-model="phone"
                />
              </div>
              <div class="mb-1">
                <label for="fax" class="form-label">Fax</label>
                <input
                  type="text"
                  class="form-control form-control-sm"
                  id="fax"
                  v-model="fax"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button
            type="button"
            class="btn btn-secondary"
            data-bs-dismiss="modal"
          >
            Close
          </button>
          <button @click="save" type="button" class="btn btn-primary">
            Save changes
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  emits: ["success"],
  data() {
    return {
      instance: null,
      companyName: null,
      contactName: null,
      contactTitle: null,
      address: null,
      city: null,
      region: null,
      postalCode: null,
      country: null,
      phone: null,
      fax: null,
      hasError: false,
    };
  },
  mounted() {
    this.instance = new bootstrap.Modal(document.getElementById("newModal"));
  },
  methods: {
    save() {
      this.hasError = false;
      let data = {
        CompanyName: this.companyName,
        ContactName: this.contactName,
        ContactTitle: this.contactTitle,
        Address: this.address,
        City: this.city,
        Region: this.region,
        PostalCode: this.postalCode,
        Country: this.country,
        Phone: this.phone,
        Fax: this.fax,
      };
      this.$ajax
        .post("/api/supplier/add", data)
        .then((response) => {
          if (response) {
            this.instance.hide();
            this.clear();
            this.$emit("success");
          }
        })
        .catch(() => {
          if (error.response.status == 401) {
            this.$router.push("/login");
          } else {
            this.hasError = true;
          }
        });
    },
    open() {
      this.hasError = false;
      this.instance.show();
    },
    clear() {
      this.companyName = null;
      this.contactName = null;
      this.contactTitle = null;
      this.address = null;
      this.city = null;
      this.region = null;
      this.postalCode = null;
      this.country = null;
      this.phone = null;
      this.fax = null;
    },
  },
};
</script>
<style scoped>
</style>