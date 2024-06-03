using System.Threading.Tasks;
using Util.Templates.HandlebarsDotNet;
using Xunit;

namespace Util.Templates.Handlebars.Tests.Integration; 

/// <summary>
/// Razorģ��������� - ��Ⱦģ���ַ���
/// </summary>
public class HandlebarsTemplateEngineTest {
    /// <summary>
    /// Razorģ������
    /// </summary>
    private readonly IHandlebarsTemplateEngine _templateEngine;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    public HandlebarsTemplateEngineTest( IHandlebarsTemplateEngine templateEngine ) {
        _templateEngine = templateEngine;
    }

    /// <summary>
    /// ������Ⱦģ�� - ��Ⱦû�����ݵ�ģ��
    /// </summary>
    [Fact]
    public void TestRender_1() {
        var result = _templateEngine.Render( "a" );
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ��Ⱦ������ģ��,ʹ���������󴫵�����
    /// </summary>
    [Fact]
    public void TestRender_2() {
        var result = _templateEngine.Render( "hello {{Name}}", new { Name = "util" } );
        Assert.Equal( "hello util", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ���ı���
    /// </summary>
    [Fact]
    public void TestRender_3() {
        var source = "<div>{{Text}}   {}</div>";
        var value = new { Text = "<���>" };
        var actual2 = _templateEngine.Render( source, value );
        Assert.Equal( "<div><���>   {}</div>", actual2 );
    }

    /// <summary>
    /// ������Ⱦģ�� - Html������
    /// </summary>
    [Fact]
    public void TestHtmlEncoder() {
        var source = "<div>{{Text2}}   {}</div>";
        var value = new { Text2 = "<���>" };
        var actual2 = _templateEngine.HtmlEncoder().Render( source, value );
        Assert.Equal( "<div>&lt;���&gt;   {}</div>", actual2 );
    }

    /// <summary>
    /// �����첽��Ⱦģ�� 
    /// </summary>
    [Fact]
    public async Task TestRenderAsync() {
        var result = await _templateEngine.RenderAsync( "a" );
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ��Ⱦ������ģ��,ʹ���������󴫵�����
    /// </summary>
    [Fact]
    public async Task TestRenderAsync_2() {
        var result = await _templateEngine.RenderAsync( "hello {{Name}}", new { Name = "util" } );
        Assert.Equal( "hello util", result );
    }
}