if (typeof trustedTypes === "undefined")
  trustedTypes = { createPolicy: (n, rules) => rules };

const policy = trustedTypes.createPolicy("my-policy", {
  createHTML: (string) => string.replace(/</g, "&lt;"),
});

function downloadFile(){
  let fileName = $('#downloadFile').val();

  $.ajax( {
    url: 'http://localhost:5262/api/downloadFile?filename=' + fileName,
    method: 'GET',
  })
}

function getFiles() {
  $.ajax({
      url: 'http://localhost:5262/api/GetFiles',
      method: 'GET',
      success: function (data) {
        let files = $('#files');
        for (i = 0; i < data.length; i++) {
          let file = document.createElement('li');
          file.innerHTML = policy.createHTML(data[i]);
          files.append(file);
        }
      },
      error: function () {
        console.log('Could not get files');
        return
      }
    }
  )
}

getFiles();
