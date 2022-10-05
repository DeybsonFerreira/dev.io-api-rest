using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;

namespace app.Api.Extensions
{
    public class ImagesExtension
    {
        //private bool UploadArquivo(string arquivo, string imgNome)
        //{
        //    if (string.IsNullOrEmpty(arquivo))
        //    {
        //        NotificarErro("Forneça uma imagem para este produto!");
        //        return false;
        //    }

        //    var imageDataByteArray = Convert.FromBase64String(arquivo);

        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgNome);

        //    if (System.IO.File.Exists(filePath))
        //    {
        //        NotificarErro("Já existe um arquivo com este nome!");
        //        return false;
        //    }

        //    System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

        //    return true;
        //}

        //#region UploadAlternativo

        //[ClaimsAuthorize("Produto", "Adicionar")]
        //[HttpPost("Adicionar")]
        //public async Task<ActionResult<ProdutoViewModel>> AdicionarAlternativo(
        //    // Binder personalizado para envio de IFormFile e ViewModel dentro de um FormData compatível com .NET Core 3.1 ou superior (system.text.json)
        //    [ModelBinder(BinderType = typeof(ProdutoModelBinder))]
        //    ProdutoImagemViewModel produtoViewModel)
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    var imgPrefixo = Guid.NewGuid() + "_";
        //    if (!await UploadArquivoAlternativo(produtoViewModel.ImagemUpload, imgPrefixo))
        //    {
        //        return CustomResponse(ModelState);
        //    }

        //    produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
        //    await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

        //    return CustomResponse(produtoViewModel);
        //}

        //[RequestSizeLimit(40000000)]
        ////[DisableRequestSizeLimit]
        //[HttpPost("imagem")]
        //public ActionResult AdicionarImagem(IFormFile file)
        //{
        //    return Ok(file);
        //}

        //private async Task<bool> UploadArquivoAlternativo(IFormFile arquivo, string imgPrefixo)
        //{
        //    if (arquivo == null || arquivo.Length == 0)
        //    {
        //        NotificarErro("Forneça uma imagem para este produto!");
        //        return false;
        //    }

        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgPrefixo + arquivo.FileName);

        //    if (System.IO.File.Exists(path))
        //    {
        //        NotificarErro("Já existe um arquivo com este nome!");
        //        return false;
        //    }

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await arquivo.CopyToAsync(stream);
        //    }

        //    return true;
        //}

        #endregion
    }
}
