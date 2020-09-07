terraform {
  required_providers {
    docker = {
      source = "terraform-providers/docker"
    }
  }
}

provider "docker" {
  host    = "npipe:////.//pipe//docker_engine"
}

resource "docker_image" "seq" {
  name         = "datalust/seq:latest"
  keep_locally = false
}

resource "docker_container" "seq" {
  image = docker_image.seq.latest
  name  = "seq"
  ports {
    internal = 80
    external = 5341
  }
  env   = ["ACCEPT_EULA=Y"]
}