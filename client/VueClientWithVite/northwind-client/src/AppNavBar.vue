<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="container-fluid">
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
          <ul class="navbar-nav" style="margin: auto; margin-right: 0">
            <li class="nav-item">
              <a class="nav-link" href="/login"><i class="bi bi-door-open"></i> Login</a>
            </li>
            
          </ul>
        </div>
      </div>
    </nav>
  </div>
</template>
<script>
export default {
  name: "AppNavBar",
};
</script>
