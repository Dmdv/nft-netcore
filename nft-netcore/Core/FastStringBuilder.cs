namespace Nft.Core;

public ref struct FastStringBuilder {
    private Span<char> _span;
    private int _pos;

    public FastStringBuilder(int maxlength) {
        _span = new Span<char>(new char[maxlength]);
        _pos = 0;
    }

    public void Append(ReadOnlySpan<char> str) {
        if (_pos + str.Length > _span.Length) throw new IndexOutOfRangeException();
        str.CopyTo(_span[_pos..]);
        _pos += str.Length;
    }

    public override string ToString() {
        return _span[.._pos].ToString();
    }
}
